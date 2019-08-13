using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateExpressions.Generated.Infrastructure;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

namespace DateExpressions.Test
{
    public class EnumerableExtensionTests
    {
        [Fact]
        public void picking_no_elements_from_empty_enumerable_returns_empty_enumerable()
        {
            Enumerable.Empty<string>()
                .PickElements(Enumerable.Empty<int>())
                .Should()
                .BeEquivalentTo(Enumerable.Empty<string>());
        }

        [Fact]
        public void picking_elements_from_empty_enumerable_returns_empty_enumerable()
        {
            Enumerable.Empty<string>()
                .PickElements(new[] {1, 3, 5})
                .Should()
                .BeEquivalentTo(Enumerable.Empty<string>());
        }

        [Fact]
        public void picking_no_elements_from_enumerable_returns_empty_enumerable()
        {
            new[] {"a","b","c"}
                .PickElements(Enumerable.Empty<int>())
                .Should()
                .BeEquivalentTo(Enumerable.Empty<string>());
        }

        [Fact]
        public void can_pick_first_element_from_enumerable()
        {
            new[] {"a", "b", "c"}
                .PickElements(new[] {0})
                .Should()
                .BeEquivalentTo(new[] {"a"});
        }

        [Fact]
        public void can_pick_second_element_from_enumerable()
        {
            new[] { "a", "b", "c" }
                .PickElements(new[] { 1 })
                .Should()
                .BeEquivalentTo(new[] { "b" });
        }

        [Fact]
        public void can_pick_more_elements_from_enumerable()
        {
            Enumerable.Range(0, 10)
                .PickElements(new[] {1, 3, 6, 7})
                .ToArray()
                .Should()
                .BeEquivalentTo(new[] {1, 3, 6, 7});
        }

        [Fact]
        public void if_enumerable_doesnt_have_enough_elements_only_present_will_be_returned()
        {
            Enumerable.Range(0, 5)
                .PickElements(new[] { 1, 3, 6, 7 })
                .ToArray()
                .Should()
                .BeEquivalentTo(new[] { 1, 3 });
        }
    }
}
